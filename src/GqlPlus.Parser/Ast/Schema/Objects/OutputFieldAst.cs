﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputFieldAst(
  TokenAt At,
  string Name,
  string Description,
  IGqlpOutputBase BaseType
) : AstObjField<IGqlpOutputBase>(At, Name, Description, BaseType)
  , IEquatable<OutputFieldAst>
  , IGqlpOutputField
{
  public IGqlpInputParam[] Params { get; set; } = [];
  public string? EnumLabel { get; set; }

  public OutputFieldAst(TokenAt at, string name, IGqlpOutputBase typeBase)
    : this(at, name, "", typeBase) { }

  internal override string Abbr => "OF";

  IEnumerable<IGqlpInputParam> IGqlpOutputField.Params => Params;
  IGqlpObjType IGqlpOutputEnum.EnumType => BaseType;

  void IGqlpOutputEnum.SetEnumType(string enumType)
  {
    EnumLabel ??= BaseType.Name;
    BaseType = (OutputBaseAst)BaseType with { Name = enumType };
  }

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Params.SequenceEqual(other.Params)
    && EnumLabel == other.EnumLabel;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Params.Length, EnumLabel);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Params.Bracket("(", ")"))
      .Concat(string.IsNullOrWhiteSpace(EnumLabel)
        ? [":", .. BaseType.GetFields(), .. Modifiers.AsString()]
        : ["=", .. BaseType.GetFields(), "." + EnumLabel]);
}
