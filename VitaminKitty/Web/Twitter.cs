using CoreTweet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VitaminKitty.Models;

namespace VitaminKitty.Web
{
    public class Twitter
    {
        private TwitterConsumer _consumer { get; set; }
        private Tokens _tokens;

        public Twitter(TwitterConsumer consumer)
        {
            _consumer = consumer;
            _tokens = Tokens.Create(_consumer.ApiKey, _consumer.ApiSecret, _consumer.AccessToken, _consumer.AccessSecret);
        }

        public void Tweet(string message)
        {
            if (_tokens == null)
            {
                return;
            }

            _tokens.Statuses.Update(status => message);
        }
    }
}
