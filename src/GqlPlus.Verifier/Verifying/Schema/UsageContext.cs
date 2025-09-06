﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public class UsageContext(
  IMap<IGqlpDescribed> types,
  IMessages errors
)
{
  internal readonly HashSet<string> Used = [];

  internal void Add(IEnumerable<IMessage> messages)
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

  internal bool GetType(string? type, [NotNullWhen(true)] out IGqlpDescribed? value)
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
    if (GetType(type, out IGqlpDescribed? descr) && descr is T t) {
      value = t;
      return true;
    }

    value = default;
    return false;
  }

  internal bool DifferentName<TAst>(SelfUsage<TAst> input, string? current)
    where TAst : IGqlpType
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

internal record struct SelfUsage<TAst>(List<string> Chain, TAst Usage, string Label)
  where TAst : IGqlpType
{
  internal readonly string? Current => Chain.FirstOrDefault();
  internal readonly bool DifferentName
  {
    get {
      if (Chain.Count == 0) {
        return true;
      }

      if (Chain.Count > 99) {
        return false;
      }

      if (Chain.Contains(Usage.Name)) {
        return false;
      }

      return !Chain.Skip(1).Contains(Current);
    }
  }

  internal readonly string UsageName => Usage.Name;
  internal readonly string UsageLabel => Usage.Label;

  internal readonly SelfUsage<TAst> AddNext(string next)
    => new([next, .. Chain], Usage, Label);

  public override readonly string? ToString()
    => $"{UsageLabel}: {UsageName} - [{Chain.Joined(" -> ")}] ({Label})";
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
}

internal delegate void CheckError(string prefix, string suffix, bool check = true);
