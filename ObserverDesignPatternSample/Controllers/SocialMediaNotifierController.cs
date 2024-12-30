using Microsoft.AspNetCore.Mvc;
using ObserverDesignPatternSample.Models;
using ObserverDesignPatternSample.Observers;

namespace ObserverDesignPatternSample.Controllers
{
    /// <summary>
    /// Controller for managing social media notifications using the Observer design pattern.
    /// Allows users to follow accounts and receive notifications on new posts.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediaNotifierController : ControllerBase
    {
        /// <summary>
        /// Stores the accounts and their associated observers (followers).
        /// </summary>
        private static readonly Dictionary<string, Account> Accounts = new();

        /// <summary>
        /// Allows a user to follow a specific account.
        /// </summary>
        /// <param name="accountName">The name of the account to follow.</param>
        /// <param name="userName">The name of the user who wants to follow the account.</param>
        /// <returns>An action result indicating the outcome of the follow operation.</returns>
        [HttpPost("follow")]
        public IActionResult Follow(string accountName, string userName)
        {
            if (!Accounts.TryGetValue(accountName, out var account))
            {
                account = new Account(accountName);
                Accounts[accountName] = account;
            }

            var user = new User(userName);
            account.Attach(user);

            return Ok($"{userName} is now following {accountName}.");
        }

        /// <summary>
        /// Creates a new post for a specific account and notifies all its followers.
        /// </summary>
        /// <param name="post">The post data, including account name and content.</param>
        /// <returns>An action result indicating the outcome of the post creation.</returns>
        [HttpPost("post")]
        public IActionResult CreatePost([FromBody] Post post)
        {
            if (!Accounts.TryGetValue(post.AccountName, out var account))
            {
                return BadRequest("Account not found.");
            }

            account.Post(post.Content);
            return Ok("Post created and followers notified.");
        }
    }
}
