﻿using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Ast.Schema.Types;

public class EnumAstTests
  : AstTypeTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, string[] enumMembers)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() });

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, string[] enumMembers)
    => _checks.Text(
      () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() },
      $"( !E {name} {enumMembers.Joined(s => "!EM " + s)} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, string[] enumMembers)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumMembers(string name, string[] enumMembers1, string[] enumMembers2)
    => _checks.InequalityBetween(enumMembers1, enumMembers2,
      enumMember => new EnumDeclAst(AstNulls.At, name) { Members = enumMember.EnumMembers() },
      enumMembers1.SequenceEqual(enumMembers2));

  private readonly AstTypeChecks<EnumDeclAst> _checks
    = new(name => new EnumDeclAst(AstNulls.At, name));

  internal override IAstTypeChecks TypeChecks => _checks;
}
