using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Ramrod.Data.Components;

/// <summary>
///     Abstract class to use as a base for forms that handle
///     <typeparam name="T"></typeparam>
///     as binded value.
/// </summary>
/// <typeparam name="T">The type of the binded value.</typeparam>
public abstract class GenericForm<T> : InputBase<T>
    where T : class
{
    /// <summary>
    ///     The <see cref="EditContext" /> to use for the form.
    /// </summary>
    public EditContext _editContext;

    /// <summary>
    ///     Holds a value to reset the form when submitted invalid value.
    /// </summary>
    public T BackupValue { get; set; }

    /// <summary>
    ///     Gets or sets a value to display on the form.
    /// </summary>
    [Parameter]
    public T TValue { get; set; }

    /// <summary>
    ///     Abstract method that retrieves a new object of type <typeparamref name="T" />
    /// </summary>
    /// <returns></returns>
    public abstract T ResetValue();

    /// <summary>
    ///     Abstract method to handle form valid submit;
    /// </summary>
    /// <param name="value">The submitted value of type <typeparamref name="T" />.</param>
    protected abstract void OnValidSubmit(T value);

    /// <summary>
    ///     Abstract method to handle form invalid submit;
    /// </summary>
    /// <param name="value">The submitted value of type <typeparamref name="T" />.</param>
    protected abstract void OnInvalidSubmit(T value);

    /// <summary>
    ///     Async method to reset the <see cref="EditContext" />.
    /// </summary>
    /// <param name="timeoutInSeconds">The timeout in seconds to display the validation error messages.</param>
    protected async void ResetContext(int timeoutInSeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));
        _editContext = new EditContext(TValue);
        StateHasChanged();
    }

    /// <summary>
    ///     Event that fired when any field of <see cref="EditContext" /> of the form changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    protected virtual void OnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        if (_editContext.Validate())
            OnValidSubmit(TValue);
        else
            OnInvalidSubmit(BackupValue);
    }

    /// <summary>
    ///     Callback function to notify the parent form of the change of the current value.
    /// </summary>
    /// <param name="value">The changed value of type <typeparamref name="T" />.</param>
    protected virtual void InvokeValueChangedCallback(T? value)
    {
        ValueChanged.InvokeAsync(value);
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, out T result, out string validationErrorMessage)
    {
        var validationResult = _editContext.Validate();
        result = validationResult
            ? TValue!
            : BackupValue!;
        validationErrorMessage = string.Join(Environment.NewLine, _editContext.GetValidationMessages());
        return validationResult;
    }
}