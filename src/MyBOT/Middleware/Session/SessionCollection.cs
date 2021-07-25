using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyBOT.Middleware.Session {
    public class SessionCollection {
        private readonly IDictionary<string, string> _sessionCollection;

        public SessionCollection() {
            _sessionCollection = new SortedDictionary<string, string>();
        }

        public bool TryAddValue(string key, object value) {
            try {
                dynamic sObj = _sessionCollection.TryGetValue(key, out var valueStr) 
                    ? JObject.Parse(valueStr) 
                    : new JObject();
                
                sObj[value.GetType().Name] = JToken.FromObject(value);
                _sessionCollection[key] = sObj.ToString(Formatting.None); // JsonConvert.SerializeObject(sObj);
                return true;
#pragma warning disable 168
            } catch (Exception ex) {
#pragma warning restore 168
                return false;
            }
        }

        public bool TryGetValue(string key, Type type, out object value) {
            try {
                if (_sessionCollection.TryGetValue(key, out var objJson)) {
                    JObject obj = JObject.Parse(objJson);
                    foreach (var prop in obj) {
                        if (prop.Key == type.Name && prop.Value != null) {
                            value = prop.Value.ToObject(type);
                            return true;
                        }
                    }
                }
                value = null;
                return false;
            }
#pragma warning disable 168
            catch (Exception ex) {
#pragma warning restore 168
                value = null;
                return false;
            }
        }
        
    }
}