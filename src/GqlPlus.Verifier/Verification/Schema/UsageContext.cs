using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Token;

namespace GqlPlus.Verification.Schema;

public class UsageContext(
  IMap<AstDescribed> types,
  ITokenMessages errors
)
{
  internal readonly HashSet<string> Used = [];

  internal void Add(IEnumerable<TokenMessage> messages)
    => errors.Add(messages);

  internal void AddError<TAst>(TAst item, string label, string message)
      where TAst : AstAbbreviated
    => errors.AddError(item, $"Invalid {label}. {message}.");

  internal bool GetType(string? type, out AstDescribed? value)
  {
    if (types.TryGetValue(type ?? "", out value)) {
      Used.Add(type!);
      return true;
    }

    value = default;
    return false;
  }

  internal virtual void CheckArgumentType<TObjBase>(TObjBase type, string labelSuffix)
    where TObjBase : AstObjectBase<TObjBase>
    => this.CheckType(type, labelSuffix);

  internal bool DifferentName<TAst>(ParentUsage<TAst> input, string? current)
    where TAst : AstType
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
  where TAst : AstType
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
  internal static TContext CheckModifiers<TContext>(this TContext context, IAstModified modified)
    where TContext : UsageContext
  {
    foreach (ModifierAst modifier in modified.Modifiers) {
      if (modifier.Kind == ModifierKind.Dict) {
        if (context.GetType(modifier.Key, out AstDescribed? key)) {
          if (key is not AstSimple and not TypeParameterAst) {
            context.AddError((AstAbbreviated)modified, "Modifier", $"'{modifier.Key}' invalid type");
          }
        } else {
          context.AddError((AstAbbreviated)modified, "Modifier", $"'{modifier.Key}' not defined");
        }
      }
    }

    return context;
  }

  internal static TContext CheckType<TContext, TObjBase>(this TContext context, TObjBase type, string labelSuffix, bool check = true)
    where TContext : UsageContext
    where TObjBase : AstObjectBase<TObjBase>
  {
    if (context.GetType(type.FullName, out AstDescribed? value)) {
      int numArgs = type.Arguments.Length;
      if (value is IAstObject definition) {
        if (check && definition.Label != "Dual" && definition.Label != type.Label) {
          context.AddError(type, type.Label + labelSuffix, $"Type kind mismatch for {type.FullName}. Found {definition.Label}");
        }

        int numParams = definition.TypeParameters.Length;
        if (numParams != numArgs) {
          context.AddError(type, type.Label + labelSuffix, $"Arguments mismatch, expected {numParams} given {numArgs}");
        }
      }
    } else if (check) {
      context.AddError(type, type.Label + labelSuffix, $"'{type.FullName}' not defined");
    }

    foreach (TObjBase arg in type.Arguments) {
      context.CheckArgumentType(arg, labelSuffix);
    }

    return context;
  }
}
