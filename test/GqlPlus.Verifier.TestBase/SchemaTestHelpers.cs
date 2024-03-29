﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

public static class SchemaTestHelpers
{
  public static AstAlternate<T>[] Alternates<T>(this string[] alternates, Func<string, T> factory)
    where T : AstReference<T>
    => [.. alternates.Select(a => new AstAlternate<T>(factory(a)) { Modifiers = TestMods() })];

  public static EnumMemberAst[] EnumMembers(this IEnumerable<string> enumMembers)
    => [.. enumMembers.Select(l => new EnumMemberAst(AstNulls.At, l))];

  public static DualFieldAst[] DualFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new DualFieldAst(AstNulls.At, f.Name, new(AstNulls.At, f.Type)))];

  public static DualReferenceAst[] DualReferences(this string[] arguments)
    => [.. arguments.Select(a => new DualReferenceAst(AstNulls.At, a))];

  public static InputFieldAst[] InputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new InputFieldAst(AstNulls.At, f.Name, new(AstNulls.At, f.Type)))];

  public static InputReferenceAst[] InputReferences(this string[] arguments)
    => [.. arguments.Select(a => new InputReferenceAst(AstNulls.At, a))];

  public static OutputFieldAst[] OutputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new OutputFieldAst(AstNulls.At, f.Name, new(AstNulls.At, f.Type)))];

  public static OutputReferenceAst[] OutputReferences(this string[] arguments)
    => [.. arguments.Select(a => new OutputReferenceAst(AstNulls.At, a))];

  public static ParameterAst[] Parameters(this IEnumerable<string> parameters)
    => [.. parameters.Select(parameter => new ParameterAst(AstNulls.At, parameter))];

  public static ParameterAst[] Parameters(this string[] parameters, Func<ParameterAst, ParameterAst> mapping)
    => [.. parameters.Select(parameter => mapping(new ParameterAst(AstNulls.At, parameter)))];

  private static TResult[] WithExcludes<TInput, TResult>(this TInput[] inputs, Func<TInput, TResult> mapping)
    where TResult : AstScalarItem
  {
    var exclude = true;

    return [.. inputs.Select(i => mapping(i) with { Excludes = exclude = !exclude })];
  }

  public static ScalarTrueFalseAst[] ScalarTrueFalses(this bool[] members)
    => [.. members.WithExcludes(r => new ScalarTrueFalseAst(AstNulls.At, false, r))];

  public static ScalarMemberAst[] ScalarMembers(this string[] members)
    => [.. members.WithExcludes(r => new ScalarMemberAst(AstNulls.At, false, r))];

  public static ScalarRangeAst[] ScalarRanges(this ScalarRangeInput[] ranges)
    => [.. ranges.WithExcludes(r => new ScalarRangeAst(AstNulls.At, false, r.Lower, r.Upper))];

  public static ScalarRegexAst[] ScalarRegexes(this string[] regexes)
    => [.. regexes.WithExcludes(r => new ScalarRegexAst(AstNulls.At, false, r))];

  public static TypeParameterAst[] TypeParameters(this string[] parameters)
    => [.. parameters.Select(parameter => new TypeParameterAst(AstNulls.At, parameter))];
}
