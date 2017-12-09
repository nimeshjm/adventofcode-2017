using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Register.Domain
{
    public class CSharpScriptEngine
    {
        private static ScriptState<object> scriptState;

        public static object Execute(string code)
        {
            var systemCore = typeof(System.Linq.Enumerable).Assembly;
            var scriptOptions = ScriptOptions.Default;
            scriptOptions = scriptOptions.AddReferences(systemCore);

            scriptState = scriptState == null ? CSharpScript.RunAsync(code, scriptOptions).Result : scriptState.ContinueWithAsync(code).Result;
            return !string.IsNullOrEmpty(scriptState.ReturnValue?.ToString()) ? scriptState.ReturnValue : null;
        }
    }
}