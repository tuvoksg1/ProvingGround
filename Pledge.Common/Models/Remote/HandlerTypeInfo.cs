using System;

namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// 
    /// </summary>
    public class HandlerTypeInfo
    {
        /// <summary>
        /// A container object for information about different handler types and their default settings
        /// </summary>
        /// <param name="handlerSetting"></param>
        /// <exception cref="InvalidOperationException">Invalid medium type provided</exception>
        public HandlerTypeInfo(HandlerSetting handlerSetting)
        {
            switch (handlerSetting.HandlerType)
            {
                case HandlerType.FileSystem:
                    Name = "File System";
                    break;
                case HandlerType.Ftp:
                    Name = "FTP";
                    break;
                case HandlerType.Smtp:
                    Name = "SMTP";
                    break;
                case HandlerType.WebService:
                    Name = "Web Service";
                    break;
                case HandlerType.Passport:
                    Name = "CX Passport";
                    break;
                default:
                    throw new InvalidOperationException("Invalid medium type provided");
            }

            Type = handlerSetting.HandlerType;
            DefaultSetting = handlerSetting;
        }

        /// <summary>
        /// The Name of the handler
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The medium handler type
        /// </summary>
        public HandlerType Type { get; private set; }
        /// <summary>
        /// Gets or sets the default settings.
        /// </summary>
        public HandlerSetting DefaultSetting { get; private set; }
    }
}
