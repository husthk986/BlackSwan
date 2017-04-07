using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _355MiniTweet : ILeetcode
    {
        public void DoIt()
        {

            Twitter obj = new Twitter();

            //obj.PostTweet(1, 5);
            //PrintResult(obj.GetNewsFeed(1));
            //obj.Follow(1, 2);
            //obj.PostTweet(2, 6);
            //PrintResult(obj.GetNewsFeed(1));
            //obj.Unfollow(1, 2);
            //PrintResult(obj.GetNewsFeed(1));

            //test case2
            obj.PostTweet(1, 1);
            obj.PostTweet(1, 2);
            obj.PostTweet(1, 3);
            obj.PostTweet(1, 4);
            obj.PostTweet(2, 5);
            obj.PostTweet(2, 6);
            obj.PostTweet(2, 7);
            obj.PostTweet(2, 8);
            PrintResult(obj.GetNewsFeed(1));
            PrintResult(obj.GetNewsFeed(2));
            obj.Follow(1,2);
            PrintResult(obj.GetNewsFeed(1));

        }

        public void PrintResult(IList<int> result)
        {
            foreach (int i in result)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }
        public class Twitter
        {

            class Node : IComparable<Node>
            {
                public int Order { get; set; }
                public int TweetId;
                public Node(int order, int tweetId)
                {
                    this.Order = order;
                    this.TweetId = tweetId;
                }
                public int CompareTo(Node other)
                {
                    if (this.Order < other.Order)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            const int mRecent = 2;
            Dictionary<int, List<Node>> mTwitterUser;
            Dictionary<int, HashSet<int>> mTwitterFollowers;
            int mOrder;

            /** Initialize your data structure here. */
            public Twitter()
            {
                mTwitterUser = new Dictionary<int, List<Node>>();
                mTwitterFollowers = new Dictionary<int, HashSet<int>>();
                mOrder = 0;
            }

            /** Compose a new tweet. */
            public void PostTweet(int userId, int tweetId)
            {
                if (!mTwitterUser.ContainsKey(userId))
                {
                    mTwitterUser.Add(userId, new List<Node>());
                }

                mOrder++;
                mTwitterUser[userId].Add(new Node(mOrder, tweetId));
            }

            /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
            public IList<int> GetNewsFeed(int userId)
            {
                List<Node> tmp = new List<Node>();
                if (mTwitterUser.ContainsKey(userId))
                {
                    tmp.AddRange(GetLastTen(mTwitterUser[userId]));
                }

                if (mTwitterFollowers.ContainsKey(userId))
                {
                    foreach (int user in mTwitterFollowers[userId])
                    {
                        if (mTwitterUser.ContainsKey(user))
                        {
                            tmp.AddRange(GetLastTen(mTwitterUser[user]));
                        }
                    }
                }

                tmp.Sort();
                List<int> ans = new List<int>();
                int size = Math.Min(tmp.Count, mRecent);
                for (int i = 0; i < size; i++)
                {
                    ans.Add(tmp[i].TweetId);
                }
                return ans;
            }

            /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
            public void Follow(int followerId, int followeeId)
            {
                if (!mTwitterFollowers.ContainsKey(followerId))
                {
                    mTwitterFollowers.Add(followerId, new HashSet<int>());
                }
                mTwitterFollowers[followerId].Add(followeeId);
            }

            /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
            public void Unfollow(int followerId, int followeeId)
            {
                if (mTwitterFollowers.ContainsKey(followerId))
                {
                    mTwitterFollowers[followerId].Remove(followeeId);
                }
            }

            private List<Node> GetLastTen(List<Node> tmp)
            {
                if (tmp.Count <= mRecent)
                {
                    return new List<Node>(tmp);
                }

                List<Node> result = new List<Node>();
                for (int i = tmp.Count - mRecent; i < tmp.Count; i++)
                {
                    result.Add(tmp[i]);
                }

                return result;
            }
        }
    }

}
