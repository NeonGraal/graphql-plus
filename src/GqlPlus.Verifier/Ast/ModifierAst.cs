﻿namespace GqlPlus.Verifier.Ast;

internal record class ModifierAst(ModifierKind Kind)
{
  internal static readonly ModifierAst Optional = new(ModifierKind.Optional);
  internal static readonly ModifierAst List = new(ModifierKind.List);

  internal ModifierAst() : this(ModifierKind.Dict) { }

  internal string? Key { get; init; }
  internal bool KeyOptional { get; init; }

  public override string ToString()
    => Kind switch {
      ModifierKind.Optional => "?",
      ModifierKind.List => "[]",
      ModifierKind.Dict => $"[{Key}" + (KeyOptional ? "?]" : "]"),
      _ => "!?!",
    };
}
