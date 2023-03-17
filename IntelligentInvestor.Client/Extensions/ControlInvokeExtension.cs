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
        var maxLength = args.Length;
        var minLength = args.Count(p => !p.IsOptional);
        return @params.Length < minLength || @params.Length > maxLength
            ? throw new ArgumentException($"Parameters count ({@params.Length}) doesn't between range of Delegate required ({minLength}~{maxLength}).")
            : control == null || !control.InvokeRequired
            ? (TReturn)@delegate.DynamicInvoke(@params)
            : (TReturn)control?.Invoke(new Func<object>(() => @delegate.DynamicInvoke(@params)));
    }

    public static object InvokeIfRequired(this Control control, Delegate @delegate, params object[] @params)
    {
        return control == null || !control.InvokeRequired
            ? @delegate.DynamicInvoke(@params)
            : (control?.Invoke(new Func<object>(() => @delegate.DynamicInvoke(@params))));
    }
}
