using System.Text;

namespace Service.ServiceHelpers
{
    internal static class RosourceBuilder
    {
        internal static StringBuilder BuildQueryString(Dictionary<string, string> parameters)
        {
            StringBuilder sb = new();
            bool isNotFirst = false;
            foreach(var parameter in parameters)
            {
                if(isNotFirst)
                {
                    sb.Append('&');
                }
                else
                {
                    isNotFirst = true;
                }
                sb.Append(parameter.Key);
                sb.Append('=');
                sb.Append(parameter.Value);
            }
            return sb;
        }

        internal static string BuildResource(string resource, string method, Dictionary<string, string> parameters)
        {
            StringBuilder sb = new();
            sb.Append(resource);
            sb.Append('/');
            sb.Append(method);
            sb.Append('?');
            sb.Append(BuildQueryString(parameters));
            return sb.ToString();
        }
    }
}
