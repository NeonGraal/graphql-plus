﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

public record class UsageContext(
  IMap<AstDescribed> Types,
  ITokenMessages Errors
)
{
  internal readonly HashSet<string> Used = [];

  internal void AddError<TAst>(TAst item, string label, string message)
      where TAst : AstAbbreviated
      => Errors.AddError(item, $"Invalid {label}. {message}.");

  internal bool GetType(string? type, out AstDescribed? value)
  {
    if (Types.TryGetValue(type ?? "", out value)) {
      Used.Add(type!);
      return true;
    }

    value = default;
    return false;
  }

  internal virtual void CheckArgumentType<TReference>(TReference type)
    where TReference : AstReference<TReference>
    => this.CheckType(type);
}

internal static class UsageHelpers
{
  internal static TContext CheckModifiers<TContext>(this TContext context, IAstModified modified)
    where TContext : UsageContext
  {
    foreach (var modifier in modified.Modifiers) {
      if (modifier.Kind == ModifierKind.Dict) {
        if (context.GetType(modifier.Key, out var key)) {
          if (key is not EnumDeclAst and not AstScalar) {
            context.AddError((AstAbbreviated)modified, "Modifier", $"'{modifier.Key}' invalid type");
          }
        } else {
          context.AddError((AstAbbreviated)modified, "Modifier", $"'{modifier.Key}' not defined");
        }
      }
    }

    return context;
  }

  internal static TContext CheckType<TContext, TReference>(this TContext context, TReference type, bool check = true)
    where TContext : UsageContext
    where TReference : AstReference<TReference>
  {
    if (context.GetType(type.FullName, out AstDescribed? value)) {
      var numArgs = type.Arguments.Length;
      if (value is IAstObject definition) {
        if (check && type.Name != "Any" && definition.Label != type.Label) {
          context.AddError(type, type.Label, $"Type kind mismatch for {type.FullName}. Found {definition.Label}");
        }

        var numParams = definition.TypeParameters.Length;
        if (numParams != numArgs) {
          context.AddError(type, type.Label, $"Arguments mismatch, expected {numParams} given {numArgs}");
        }
      }
    } else if (check) {
      context.AddError(type, type.Label, $"'{type.FullName}' not defined");
    }

    foreach (var arg in type.Arguments) {
      context.CheckArgumentType(arg);
    }

    return context;
  }
}
