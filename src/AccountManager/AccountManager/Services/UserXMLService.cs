// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using AccountManager.Models;

namespace AccountManager.Services
{
  internal class UserXMLService
  {
    private readonly string _path;

    public UserXMLService(string path) => _path = path;

    public List<User> Load()
    {
      if (!File.Exists(_path)) return new List<User>();

      var serializer = new XmlSerializer(typeof(List<User>));
      using (var stream = File.OpenRead(_path))
        return (List<User>)serializer.Deserialize(stream);
    }

    public void Save(List<User> users)
    {
      var serializer = new XmlSerializer(typeof(List<User>));
      using (var stream = File.Create(_path))
        serializer.Serialize(stream, users);
    }
  }
}
