using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public class UsageContext(
  IMap<IAstDescribed> types,
  IMessages errors
)
{
  internal readonly HashSet<string> Used = [];

  internal void Add(IEnumerable<IMessage> messages)
    => errors.Add(messages);

  internal void AddError<TAst>(TAst item, string label, string message)
      where TAst : IAstError
    => errors.Add(item.MakeError($"Invalid {label}. {message}."));

  internal void AddError<TAst>(
    TAst item,
    string label,
    FormattableString message,
    bool addError
  )
      where TAst : IAstError
  {
    if (addError) {
      errors.Add(item.MakeError($"Invalid {label}. {message}."));
    }
  }

  internal bool GetType(string? type, [NotNullWhen(true)] out IAstDescribed? value)
  {
    if (types.TryGetValue(type.IfWhiteSpace(), out value)) {
      Used.Add(type!);
      return true;
    }

    value = default;
    return false;
  }

  internal bool GetTyped<T>(string? type, [NotNullWhen(true)] out T? value)
  {
    if (GetType(type, out IAstDescribed? descr) && descr is T t) {
      value = t;
      return true;
    }

    value = default;
    return false;
  }

  internal bool DifferentName<TAst>(SelfUsage<TAst> input, string? current)
    where TAst : IAstType
  {
    if (input.DifferentName) {
      return true;
    }

    string message = $"'{input.UsageName}' cannot be {input.Label} of itself";
    if (!string.IsNullOrEmpty(current)) {
      message += $", even recursively via {current}";
    }

    AddError(input.Usage, input.UsageLabel, message);
    return false;
  }
}

internal record struct SelfUsage<TAst>(string Head, TAst Usage, string Label)
  where TAst : IAstType
{
  private List<string> _chain = [Head];

  internal TypeKind Kind { get; } = Usage.Kind;
  internal readonly string Current => _chain.First();
  internal readonly bool DifferentName
  {
    get {
      if (_chain.Count > 99) {
        return false;
      }

      if (_chain.Contains(Usage.Name)) {
        return false;
      }

      return !_chain.Skip(1).Contains(Current);
    }
  }

  internal readonly string UsageName => Usage.Name;
  internal readonly string UsageLabel => Usage.Label;

  internal readonly SelfUsage<TAst> AddNext(string next)
    => new SelfUsage<TAst>(next, Usage, Label) with { _chain = [next, .. _chain] };
}

internal static class UsageHelpers
{
  internal static TContext CheckModifiers<TContext>(this TContext context, IAstModifiers modified)
    where TContext : UsageContext
  {
    foreach (IAstModifier modifier in modified.Modifiers) {
      switch (modifier.ModifierKind) {
        case ModifierKind.Param:
          CheckParam(modifier.Key);
          break;
        case ModifierKind.Dict:
          CheckKey(modifier.Key);
          break;
        default:
          break;
      }
    }

    return context;

    void CheckParam(string? paramName)
    {
      if (context.GetType("$" + paramName, out IAstDescribed? key)) {
        if (key is IGqlpTypeParam typeParam) {
          CheckKey(typeParam.Constraint, $"constraint '{typeParam.Constraint}' ");
        }
      } else {
        context.AddError((IAstAbbreviated)modified, "Modifier", $"'{paramName}' not defined");
      }
    }

    void CheckKey(string? keyName, string label = "")
    {
      if (context.GetType(keyName, out IAstDescribed? key)) {
        context.AddError((IAstAbbreviated)modified, "Modifier", $"{label}'{keyName}' invalid type", key is not IAstSimple and not IGqlpTypeParam);
      } else {
        context.AddError((IAstAbbreviated)modified, "Modifier", $"{label}'{keyName}' not defined");
      }
    }
  }
}

internal delegate void CheckError(string prefix, string suffix, bool addError = true);
