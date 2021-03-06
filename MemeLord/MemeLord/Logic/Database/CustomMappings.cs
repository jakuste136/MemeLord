﻿using MemeLord.Models;
using NPoco.FluentMappings;

namespace MemeLord.Logic.Database
{
    public class CustomMappings : Mappings
    {
        public CustomMappings()
        {
            For<Comment>()
                .TableName("Comments")
                .PrimaryKey(c => c.Id, autoIncrement: true)
                .Columns(b =>
                {
                    b.Column(comment => comment.User).WithName("UserId").Reference(user => user.Id);
                    b.Column(comment => comment.Post).WithName("PostId").Reference(post => post.Id);
                    b.Column(comment => comment.MasterComment).WithName("MasterCommentId").Reference(comment => comment.Id);
                    b.Column(comment => comment.Answers).Ignore();
                });

            For<Following>()
                .TableName("Followings")
                .CompositePrimaryKey(f => f.Follower, f => f.Followed)
                .Columns(b =>
                {
                    b.Column(following => following.Followed).WithName("FollowedId").Reference(user => user.Id);
                    b.Column(following => following.Follower).WithName("FollowerId").Reference(user => user.Id);
                });

            For<Like>()
                .TableName("Likes")
                .PrimaryKey(l => l.Id, autoIncrement: true)
                .Columns(b =>
                {
                    b.Column(like => like.User).WithName("UserId").Reference(user => user.Id);
                    b.Column(like => like.Post).WithName("PostId").Reference(post => post.Id);
                    b.Column(like => like.Comment).WithName("CommentId").Reference(comment => comment.Id);
                });

            For<Notification>()
                .TableName("Notifications")
                .PrimaryKey(n => n.Id, autoIncrement: true)
                .Columns(b =>
                {
                    b.Column(noti => noti.NotificationType).WithName("NotificationTypeId").Reference(type => type.Id);
                    b.Column(noti => noti.Post).WithName("PostId").Reference(post => post.Id);
                    b.Column(noti => noti.User).WithName("UserId").Reference(user => user.Id);
                });

            For<NotificationType>()
                .TableName("NotificationTypes")
                .PrimaryKey(n => n.Id, autoIncrement: true);

            For<Post>()
                .TableName("Posts")
                .PrimaryKey(p => p.Id, autoIncrement: true)
                .Columns(b =>
                {
                    b.Column(post => post.Op).WithName("OpId").Reference(user => user.Id);
                });

            For<Report>()
                .TableName("Reports")
                .PrimaryKey(r => r.Id, autoIncrement: true)
                .Columns(b =>
                {
                    b.Column(report => report.Post).WithName("PostId").Reference(post => post.Id);
                    b.Column(report => report.Comment).WithName("CommentId").Reference(comment => comment.Id);
                    b.Column(report => report.ReportType).WithName("ReportTypeId").Reference(type => type.Id);
                    b.Column(report => report.Reporter).WithName("ReporterId").Reference(user => user.Id);
                });

            For<ReportType>()
                .TableName("ReportTypes")
                .PrimaryKey(t => t.Id, autoIncrement: true);

            For<Role>()
                .TableName("Roles")
                .PrimaryKey(r => r.Id, autoIncrement: true);

            For<UserRole>()
                .TableName("UserRoles")
                .CompositePrimaryKey(ur => ur.User, ur => ur.Role)
                .Columns(b =>
                {
                    b.Column(userRole => userRole.User).WithName("UserId").Reference(user => user.Id);
                    b.Column(userRole => userRole.Role).WithName("RoleId").Reference(role => role.Id);
                });

            For<User>()
                .TableName("Users")
                .PrimaryKey(u => u.Id, autoIncrement: true)
                .Columns(b =>
                {
                    b.Column(user => user.Sex).WithDbType<string>();
                });
        }
    }
}