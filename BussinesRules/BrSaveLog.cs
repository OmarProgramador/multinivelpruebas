
namespace BusinessRules
{
    using System.IO;
    using System.Reflection;
    public class BrSaveLog
    {
        public static void SaveLog<T>(T obj, string archive)
        {
            PropertyInfo[] propertyInfo = obj.GetType().GetProperties();
            using (StreamWriter streamWriter = new StreamWriter(archive, true))
            {
                object value;
                foreach (PropertyInfo property in propertyInfo)
                {
                    value = property.GetValue(obj, null);
                    streamWriter.WriteLine("{0}={1}", property.Name, value != null ? value.ToString() : "");
                }
                streamWriter.WriteLine(new string('_', 60));
            }
        }
    }
}
