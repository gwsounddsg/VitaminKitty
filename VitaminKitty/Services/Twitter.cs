using CoreTweet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using VitaminKitty.Models;

namespace VitaminKitty.Services
{
    public class Twitter
    {
        private TwitterConsumer _consumer { get; set; }
        private Tokens _tokens { get; set; }

        public Twitter(TwitterConsumer consumer)
        {
            _consumer = consumer;
            _tokens = Tokens.Create(_consumer.ApiKey, _consumer.ApiSecret, _consumer.AccessToken, _consumer.AccessSecret);
        }

        public void Tweet(string message, FileInfo image=null)
        {
            if (_tokens == null)
            {
                return;
            }

            if (image == null)
            {
                _tokens.Statuses.Update(status => message);
            }
            else
            {
                var media = _tokens.Media.Upload(image);
                _tokens.Statuses.Update(status: message, media_ids: new long[] { media.MediaId });
            }
        }
    }
}
