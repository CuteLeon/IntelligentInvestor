namespace IntelligentInvestor.Client.Extensions;

public static class ControlInvokeExtension
{
    public static TReturn InvokeIfRequired<TReturn, TDelegate>(this Control control, TDelegate @delegate, params object[] @params)
            where TDelegate : Delegate
    {
        if (@delegate == null || @delegate.Method == null)
        {
            throw new ArgumentNullException(nameof(@delegate));
        }

        var returnType = typeof(TReturn);
        var returnDelegate = @delegate.Method.ReturnType;
        if (returnDelegate != returnType && !returnDelegate.IsSubclassOf(returnType))
        {
            throw new ArgumentException($"Declared return type {nameof(TReturn)} doesn't match return type {returnType.Name} of Delegate {returnDelegate.Name}.");
        }

        var args = @delegate.Method.GetParameters();
        int maxLength = args.Length;
        int minLength = args.Count(p => !p.IsOptional);
        if (@params.Length < minLength || @params.Length > maxLength)
        {
            throw new ArgumentException($"Parameters count ({@params.Length}) doesn't between range of Delegate required ({minLength}~{maxLength}).");
        }

        if (control == null || !control.InvokeRequired)
        {
            return (TReturn)@delegate.DynamicInvoke(@params);
        }
        else
        {
            return (TReturn)control?.Invoke(new Func<object>(() => @delegate.DynamicInvoke(@params)));
        }
    }

    public static object InvokeIfRequired(this Control control, Delegate @delegate, params object[] @params)
    {
        if (control == null || !control.InvokeRequired)
        {
            return @delegate.DynamicInvoke(@params);
        }
        else
        {
            return control?.Invoke(new Func<object>(() => @delegate.DynamicInvoke(@params)));
        }
    }
}
