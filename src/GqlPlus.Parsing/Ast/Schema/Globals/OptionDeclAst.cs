﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

public sealed record class OptionDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description)
  , IEquatable<OptionDeclAst>
  , IGqlpSchemaOption
{
  public OptionSettingAst[] Settings { get; set; } = [];

  internal override string Abbr => "Op";
  public override string Label => "Option";

  IEnumerable<IGqlpSetting> IGqlpSchemaOption.Settings => Settings;

  public OptionDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(OptionDeclAst? other)
    => base.Equals(other)
    && Settings.SequenceEqual(other.Settings);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Settings.Length);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Concat(Settings.Bracket("{", "}"));
}
