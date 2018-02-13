using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using LoggingUtility;

namespace Windows.Models.Reflection.Cron
{
    public class TaskRunner
    {
        internal static string ExecuteInstance()
        {
            const string assemblyPath = @"C:\PledgeJob\CLI\Test\DynamicContainer.dll";
            const string typeName = "DynamicContainer.ListUploader";
            //const string assemblyPath = @"C:\PledgeJob\CLI\Lists\Pledge.Remote.dll";
            //const string typeName = "Pledge.Remote.ListUploader";
            var assemblyFile = Path.GetFileName(assemblyPath);
            var resultText = string.Empty;
            AppDomain domain = null;

            try
            {
                resultText = LoadConfig(assemblyPath, typeName);
                ////Create the new application domain
                //var setup = new AppDomainSetup
                //{
                //    ApplicationBase = assemblyPath,
                //    ConfigurationFile = $@"{assemblyPath}.config",
                //    ShadowCopyFiles = "false",
                //    ApplicationName = "TaskRunnerContainer",
                //    PrivateBinPath = assemblyPath
                //};

                ////domain = AppDomain.CreateDomain($"{assemblyFile} Domain",
                ////    AppDomain.CurrentDomain.Evidence, setup);

                //domain = AppDomain.CreateDomain($"{assemblyFile} Domain");



                //LogReferences(domain);

                ////Execute the application in the new appdomain
                //var instance = domain.CreateInstanceFrom(assemblyPath, typeName);
                //var instanceType = instance.GetType();
                //var methodInfo = instanceType.GetMethod("ReplaceList");
                //if (methodInfo != null)
                //{
                //    var result = methodInfo.Invoke(instance, new object[]
                //    {
                //        string.Empty,
                //        string.Empty, string.Empty, string.Empty, string.Empty
                //    });

                //    if (result != null)
                //    {
                //        resultText = result.ToString();
                //    }
                //}
                //else
                //{
                //    resultText = "The target method could not be found";
                //}
            }
            catch (Exception e)
            {
                resultText = $"{e.Message}{Environment.NewLine}{e.StackTrace}";
            }
            finally
            {
                if (domain != null)
                {
                    AppDomain.Unload(domain);
                }
            }

            return resultText;
        }

        private static void LogReferences(AppDomain domain)
        {
            var logger = LogUtility.CreateLogger("ProvingGround", null, null, LogLevel.All, LogMode.Implicit);
            var assemblies = domain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                logger.AddMessage(MessageType.Trace, $@"{assembly.FullName}");
                var references = assembly.GetReferencedAssemblies();

                foreach (var reference in references)
                {
                    logger.AddMessage(MessageType.Trace, $@"*****{reference.FullName}");
                }
            }
        }

        public static string LoadConfig(string assemblyPath, string typeName)
        {
            var assemblyFile = Path.GetFileName(assemblyPath);
            var assembly = Assembly.LoadFile(assemblyPath);
            var type = assembly.GetType(typeName);
            var resultText = string.Empty;

            if (assemblyFile != null)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("ReplaceList");

                if (methodInfo != null)
                {
                    var result = methodInfo.Invoke(instance, new object[]
                    {
                        "DealerCodes",
                        string.Empty, assemblyPath, string.Empty, "Maritz"
                    });

                    if (result != null)
                    {
                        resultText = result.ToString();
                    }
                }
                else
                {
                    resultText = "The target method could not be found";
                }
            }

            return resultText;
        }
    }
}
