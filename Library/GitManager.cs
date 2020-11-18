using LibGit2Sharp;
using LibGit2Sharp.Handlers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace CovidItalyAnalyzer.Library
{
    public static class GitManager
    {
        public static async Task<(bool result, string message)> GitPull()
        {

            string clonedRepoPath = Repository.Clone

            using (var repo = new Repository(clonedRepoPath))
            {
                var masterBranch = repo.Branches["master"];
                var latestCommit = masterBranch.Tip;

                var blob = latestCommit["path/to/your/file.txt"].Target as Blob;

                Console.WriteLine(blob.GetContentText());
            }

            return (true, "");
        }
        public static async Task<(bool result, string message)> GitPullold()
        {
            using (var repo = new Repository(SettingManager.FolderData))
            {
                // Credential information to fetch
                LibGit2Sharp.PullOptions options = new LibGit2Sharp.PullOptions();
                options.FetchOptions = new FetchOptions();
                //options.FetchOptions.CredentialsProvider = new CredentialsHandler(
                //    (url, usernameFromUrl, types) =>
                //        new UsernamePasswordCredentials()
                //        {
                //            Username = SettingManager.UserName,
                //            Password = SettingManager.Password
                //        });

                https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-regioni.json

                // User information to create a merge commit
                var signature = new LibGit2Sharp.Signature(
                    new Identity("john.doe", "john.doe@dummy.com"), DateTimeOffset.Now);

                // Pull
                return await Task.Run(() =>
                {
                    try
                    {
                        var result = Commands.Pull(repo, signature, options);
                        switch (result.Status)
                        {
                            case MergeStatus.UpToDate:
                                MessageBox.Show(Properties.Resources.GitUpToDate);
                                break;
                            case MergeStatus.Conflicts:
                                MessageBox.Show(Properties.Resources.GitConflict);
                                break;
                            case MergeStatus.FastForward:
                                MessageBox.Show(Properties.Resources.GitFastForward);
                                break;
                        }
                        return (result.Status == MergeStatus.FastForward, "");
                    }
                    catch (Exception e)
                    {
                        return (false, e.Message);
                    }

                });
            }
        }

        public static async Task<(bool result, string message)> GitClone()
        {
            var co = new CloneOptions();
            co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = SettingManager.UserName, Password = SettingManager.Password };
            return await Task.Run(() =>
            {
                try
                {
                    var result = Repository.Clone("https://github.com/pcm-dpc/COVID-19.git", SettingManager.FolderData, co);
                }
                catch (Exception e)
                {
                    return (false, e.Message);
                }
                return (true, "");
            });
        }
    }
}
