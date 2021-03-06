﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public interface IMessageBuilderImplementation
    {
        void Reset();
        IMessageImplementation Result { get; }

        void SetTextBody(string textBody);
        void SetHtmlBody(string htmlBody);

        void AddFrom(string email);
        void RemoveFrom(string email);

        void AddTo(string email);
        void RemoveTo(string email);

        string AddResource(string filePath);
        void AddAttachment(string filePath);
    }
}
