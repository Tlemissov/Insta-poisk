using System;

namespace InstaPoisk.Common
{
    public interface IPublish
    {
        bool IsPublish { get; set; }

        DateTime? PublishDate { get; set; }
    }
}
