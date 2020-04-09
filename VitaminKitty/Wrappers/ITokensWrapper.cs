using CoreTweet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VitaminKitty.Wrappers
{
    public interface ITokensWrapper
    {
        public StatusResponse Update(string message);
        public StatusResponse Update(string status, IEnumerable<long> media_ids);
        public MediaUploadResult UpdateMedia(FileInfo fileInfo);
    }
}
