using _project.Scripts.Game.Infrastructure;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Extentions
{
    public abstract class SignalListener : MonoBehaviour
    {
        protected Signal Signal => ServiceLocator.Instance.GetInstance<Signal>();


        private void OnDisable()
        {
        }
    }

    public abstract class SignalListener<T> : SignalListener
        where T : struct
    {
        private void OnEnable()
        {
            Signal.Subscribe<T>(OnSignal);
        }

        protected abstract void OnSignal(T data);

        private void OnDisable()
        {
            Signal.Unsubscribe<T>(OnSignal);
        }
    }

    public abstract class SignalListener<T1, T2> : SignalListener
        where T1 : struct
        where T2 : struct
    {
        private void OnEnable()
        {
            Signal.Subscribe<T1>(OnSignal);
            Signal.Subscribe<T2>(OnSignal);
        }

        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);

        private void OnDisable()
        {
            Signal.Unsubscribe<T1>(OnSignal);
            Signal.Unsubscribe<T2>(OnSignal);
        }
    }

    public abstract class SignalListener<T1, T2, T3> : SignalListener
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        private void OnEnable()
        {
            Signal.Subscribe<T1>(OnSignal);
            Signal.Subscribe<T2>(OnSignal);
            Signal.Subscribe<T3>(OnSignal);
        }

        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);

        private void OnDisable()
        {
            Signal.Unsubscribe<T1>(OnSignal);
            Signal.Unsubscribe<T2>(OnSignal);
            Signal.Unsubscribe<T3>(OnSignal);
        }
    }

    public abstract class SignalListener<T1, T2, T3, T4> : SignalListener
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        private void OnEnable()
        {
            Signal.Subscribe<T1>(OnSignal);
            Signal.Subscribe<T2>(OnSignal);
            Signal.Subscribe<T3>(OnSignal);
            Signal.Subscribe<T4>(OnSignal);
        }

        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);

        private void OnDisable()
        {
            Signal.Unsubscribe<T1>(OnSignal);
            Signal.Unsubscribe<T2>(OnSignal);
            Signal.Unsubscribe<T3>(OnSignal);
            Signal.Unsubscribe<T4>(OnSignal);
        }
    }

    public abstract class SignalListener<T1, T2, T3, T4, T5> : SignalListener
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        private void OnEnable()
        {
            Signal.Subscribe<T1>(OnSignal);
            Signal.Subscribe<T2>(OnSignal);
            Signal.Subscribe<T3>(OnSignal);
            Signal.Subscribe<T4>(OnSignal);
            Signal.Subscribe<T5>(OnSignal);
        }

        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);

        private void OnDisable()
        {
            Signal.Unsubscribe<T1>(OnSignal);
            Signal.Unsubscribe<T2>(OnSignal);
            Signal.Unsubscribe<T3>(OnSignal);
            Signal.Unsubscribe<T4>(OnSignal);
            Signal.Unsubscribe<T5>(OnSignal);
        }
    }

    public abstract class SignalListener<T1, T2, T3, T4, T5, T6> : SignalListener
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
    {
        private void OnEnable()
        {
            Signal.Subscribe<T1>(OnSignal);
            Signal.Subscribe<T2>(OnSignal);
            Signal.Subscribe<T3>(OnSignal);
            Signal.Subscribe<T4>(OnSignal);
            Signal.Subscribe<T5>(OnSignal);
            Signal.Subscribe<T6>(OnSignal);
        }

        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);

        private void OnDisable()
        {
            Signal.Unsubscribe<T1>(OnSignal);
            Signal.Unsubscribe<T2>(OnSignal);
            Signal.Unsubscribe<T3>(OnSignal);
            Signal.Unsubscribe<T4>(OnSignal);
            Signal.Unsubscribe<T5>(OnSignal);
            Signal.Unsubscribe<T6>(OnSignal);
        }
    }

    public abstract class SignalListener<T1, T2, T3, T4, T5, T6, T7> : SignalListener
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
    {
        private void OnEnable()
        {
            Signal.Subscribe<T1>(OnSignal);
            Signal.Subscribe<T2>(OnSignal);
            Signal.Subscribe<T3>(OnSignal);
            Signal.Subscribe<T4>(OnSignal);
            Signal.Subscribe<T5>(OnSignal);
            Signal.Subscribe<T6>(OnSignal);
            Signal.Subscribe<T7>(OnSignal);
        }

        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);
        protected abstract void OnSignal(T7 data);

        private void OnDisable()
        {
            Signal.Unsubscribe<T1>(OnSignal);
            Signal.Unsubscribe<T2>(OnSignal);
            Signal.Unsubscribe<T3>(OnSignal);
            Signal.Unsubscribe<T4>(OnSignal);
            Signal.Unsubscribe<T5>(OnSignal);
            Signal.Unsubscribe<T6>(OnSignal);
            Signal.Unsubscribe<T7>(OnSignal);
        }
    }
}