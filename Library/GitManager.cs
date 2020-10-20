using LibGit2Sharp;
using LibGit2Sharp.Handlers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CovidItalyAnalyzer.Library
{
    public static class GitManager
    {

        public static bool GitPull()
        {
            using (var repo = new Repository(SettingManager.FolderData))
            {
                // Credential information to fetch
                LibGit2Sharp.PullOptions options = new LibGit2Sharp.PullOptions();
                options.FetchOptions = new FetchOptions();
                options.FetchOptions.CredentialsProvider = new CredentialsHandler(
                    (url, usernameFromUrl, types) =>
                        new UsernamePasswordCredentials()
                        {
                            Username = SettingManager.UserName,
                            Password = SettingManager.Password
                        });

                // User information to create a merge commit
                var signature = new LibGit2Sharp.Signature(
                    new Identity(SettingManager.UserName, SettingManager.Email), DateTimeOffset.Now);

                // Pull
                var result = Commands.Pull(repo, signature, options);
                MessageBox.Show(result.Status.ToString());
                return result.Status == MergeStatus.FastForward;
            }
        }

        public static bool GitClone()
        {
            var co = new CloneOptions();
            co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = SettingManager.UserName, Password = SettingManager.Password };
            var result = Repository.Clone("https://github.com/pcm-dpc/COVID-19.git", SettingManager.FolderData, co);
            return true;
        }
    }
}
