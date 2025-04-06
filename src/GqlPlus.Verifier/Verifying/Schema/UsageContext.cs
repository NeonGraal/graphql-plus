using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public class UsageContext(
  IMap<IGqlpDescribed> types,
  ITokenMessages errors
)
{
  internal readonly HashSet<string> Used = [];

  internal void Add(IEnumerable<ITokenMessage> messages)
    => errors.Add(messages);

  internal void AddError<TAst>(TAst item, string label, string message)
      where TAst : IGqlpError
    => errors.Add(item.MakeError($"Invalid {label}. {message}."));

  internal void AddError<TAst>(TAst item, string label, FormattableString message, bool addError)
      where TAst : IGqlpError
  {
    if (addError) {
      errors.Add(item.MakeError($"Invalid {label}. {message}."));
    }
  }

  internal bool GetType(string? type, out IGqlpDescribed? value)
  {
    if (types.TryGetValue(type ?? "", out value)) {
      Used.Add(type!);
      return true;
    }

    value = default;
    return false;
  }

  internal virtual void CheckArgType<TObjArg>(TObjArg type, string labelSuffix)
    where TObjArg : IGqlpObjArg
    => this.CheckType(type, labelSuffix);

  internal bool DifferentName<TAst>(ParentUsage<TAst> input, string? current)
    where TAst : IGqlpType
  {
    if (input.DifferentName) {
      return true;
    }

    string message = $"'{input.UsageName}' cannot be {input.Label} of itself";
    if (current is not null) {
      message += $", even recursively via {current}";
    }

    AddError(input.Usage, input.UsageLabel, message);
    return false;
  }
}

internal record struct ParentUsage<TAst>(List<string> Parents, TAst Usage, string Label)
  where TAst : IGqlpType
{
  internal readonly string? Parent => Parents?.FirstOrDefault();
  internal readonly bool DifferentName => !Parents.Contains(Usage.Name);
  internal readonly string UsageName => Usage.Name;
  internal readonly string UsageLabel => Usage.Label;

  internal readonly ParentUsage<TAst> AddParent(string parent)
    => new([parent, .. Parents], Usage, Label);

  public override readonly string? ToString()
    => $"{UsageLabel}: {UsageName} - [{Parents.Joined()}] ({Label})";
}

internal static class UsageHelpers
{
  internal static TContext CheckModifiers<TContext>(this TContext context, IGqlpModifiers modified)
    where TContext : UsageContext
  {
    foreach (IGqlpModifier modifier in modified.Modifiers) {
      if (modifier.ModifierKind == ModifierKind.Param) {
        if (!context.GetType("$" + modifier.Key, out IGqlpDescribed? key)) {
          context.AddError((IGqlpAbbreviated)modified, "Modifier", $"'{modifier.Key}' not defined");
        }
      }

      if (modifier.ModifierKind == ModifierKind.Dict) {
        if (context.GetType(modifier.Key, out IGqlpDescribed? key)) {
          context.AddError((IGqlpAbbreviated)modified, "Modifier", $"'{modifier.Key}' invalid type", key is not IGqlpSimple and not IGqlpTypeParam);
        } else {
          context.AddError((IGqlpAbbreviated)modified, "Modifier", $"'{modifier.Key}' not defined");
        }
      }
    }

    return context;
  }

  internal static TContext CheckArgs<TContext, TObjArg>(this TContext context, IEnumerable<TObjArg> arguments, string labelSuffix)
    where TContext : UsageContext
    where TObjArg : IGqlpObjArg
  {
    foreach (TObjArg arg in arguments) {
      context.CheckArgType(arg, labelSuffix);
    }

    return context;
  }

  internal static TContext CheckType<TContext, TObjBase>(this TContext context, TObjBase type, string labelSuffix, bool check = true)
    where TContext : UsageContext
    where TObjBase : IGqlpObjType
  {
    if (type is null) {
      return context;
    }

    string typeName = (type.IsTypeParam ? "$" : "") + type.Name;
    if (context.GetType(typeName, out IGqlpDescribed? value)) {
      CheckTypeArgs(AddCheckError, type, check, value);
    } else {
      context.AddError(type, type.Label + labelSuffix, $"'{typeName}' not defined", check);
    }

    return context;

    void AddCheckError(string prefix, string suffix)
      => context.AddError(type, type.Label + labelSuffix, $"{prefix} {typeName}. {suffix}");
  }

  internal delegate void CheckError(string prefix, string suffix);

  internal static void CheckTypeArgs<TObjBase>(CheckError error, TObjBase type, bool check, IGqlpDescribed? value)
    where TObjBase : IGqlpObjType
  {
    int numArgs = type is IGqlpObjBase baseType ? baseType.Args.Count() : 0;
    if (value is IGqlpObject definition) {
      if (check && definition.Label != "Dual" && definition.Label != type.Label) {
        error("Type kind mismatch for", $"Found {definition.Label}");
      }

      int numParams = definition.TypeParams.Count();
      if (numParams != numArgs) {
        error("Args mismatch on", $"Expected {numParams}, given {numArgs}");
      }
    } else if (value is IGqlpSimple simple && numArgs != 0) {
      error("Args invalid on", $"Expected 0, given {numArgs}");
    }
  }
}
