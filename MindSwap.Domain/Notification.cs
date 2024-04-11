using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Domain
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key for the user who received the notification
        public int RecipientId { get; set; }

        // Navigation property for the user who received the notification
        public User Recipient { get; set; }
    }
}
