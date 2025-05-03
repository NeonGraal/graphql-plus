﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class OptionDeclAst(
  ITokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description)
  , IEquatable<OptionDeclAst>
  , IGqlpSchemaOption
{
  public OptionSettingAst[] Settings { get; set; } = [];

  internal override string Abbr => "Op";
  public override string Label => "Option";

  IEnumerable<IGqlpSchemaSetting> IGqlpSchemaOption.Settings => Settings;

  public OptionDeclAst(ITokenAt at, string name)
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
