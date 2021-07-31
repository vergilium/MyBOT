using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace MyBOT.Models.Session {
    public class SessionObject : DynamicObject, IEnumerator, IEnumerable {
        private readonly Dictionary<string, object> _sessionObject = new Dictionary<string, object>();
            
            public int Count => _sessionObject.Count;
            
            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                string name = binder.Name.ToLower();
                return _sessionObject.TryGetValue(name, out result);
            }
            
            public override bool TrySetMember(SetMemberBinder binder, object value) {
                _sessionObject[binder.Name.ToLower()] = value;
                return true;
            }

            public bool Add( object value, string prop = null) {
                prop ??= value.GetType().Name;
                _sessionObject[prop.ToLower()] = value;
                return true;
            }
            
            public bool MoveNext() {
                return _sessionObject.GetEnumerator().MoveNext();
            }

            public void Reset() {
                _sessionObject.GetEnumerator().Dispose();
            }

            public object Current => _sessionObject.GetEnumerator().Current;
            
            public IEnumerator GetEnumerator() {
                return _sessionObject.GetEnumerator();
            }
    }
}