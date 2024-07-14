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
          if (key is not IGqlpSimple and not IGqlpTypeParam) {
            context.AddError((IGqlpAbbreviated)modified, "Modifier", $"'{modifier.Key}' invalid type");
          }
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
    if (context.GetType(type.TypeName, out IGqlpDescribed? value)) {
      int numArgs = type is IGqlpObjBase baseType ? baseType.Args.Count() : 0;
      if (value is IGqlpObject definition) {
        if (check && definition.Label != "Dual" && definition.Label != type.Label) {
          context.AddError(type, type.Label + labelSuffix, $"Type kind mismatch for {type.TypeName}. Found {definition.Label}");
        }

        int numParams = definition.TypeParams.Count();
        if (numParams != numArgs) {
          context.AddError(type, type.Label + labelSuffix, $"Args mismatch, expected {numParams} given {numArgs}");
        }
      } else if (value is IGqlpSimple simple && numArgs != 0) {
        context.AddError(type, type.Label + labelSuffix, $"Args invalid on {simple.Name}, given {numArgs}");
      }
    } else if (check) {
      context.AddError(type, type.Label + labelSuffix, $"'{type.TypeName}' not defined");
    }

    return context;
  }
}
