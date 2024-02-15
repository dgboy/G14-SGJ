namespace Core.Common {
    public class Observable<T> {
        public Observable(T value = default) => _value = value;

        public event System.Action OnChanged;
        private T _value;

        public T Value {
            get => _value;
            set {
                if (_value.Equals(value))
                    return;

                _value = value;
                OnChanged?.Invoke();
            }
        }
    }
}