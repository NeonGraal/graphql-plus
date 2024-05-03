using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

public static class SchemaTestHelpers
{
  public static AstAlternate<T>[] Alternates<T>(this string[] alternates, Func<string, T> factory)
    where T : AstObjectBase<T>
    => [.. alternates.Select(a => new AstAlternate<T>(factory(a)) { Modifiers = TestMods() })];

  public static EnumMemberAst[] EnumMembers(this IEnumerable<string> enumMembers)
    => [.. enumMembers.Select(l => new EnumMemberAst(AstNulls.At, l))];

  public static DualFieldAst[] DualFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new DualFieldAst(AstNulls.At, f.Name, new(AstNulls.At, f.Type)))];

  public static DualBaseAst[] DualBases(this string[] arguments)
    => [.. arguments.Select(a => new DualBaseAst(AstNulls.At, a))];

  public static InputFieldAst[] InputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new InputFieldAst(AstNulls.At, f.Name, new(AstNulls.At, f.Type)))];

  public static InputBaseAst[] InputBases(this string[] arguments)
    => [.. arguments.Select(a => new InputBaseAst(AstNulls.At, a))];

  public static OutputFieldAst[] OutputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new OutputFieldAst(AstNulls.At, f.Name, new(AstNulls.At, f.Type)))];

  public static OutputBaseAst[] OutputBases(this string[] arguments)
    => [.. arguments.Select(a => new OutputBaseAst(AstNulls.At, a))];

  public static ParameterAst[] Parameters(this IEnumerable<string> parameters)
    => [.. parameters.Select(parameter => new ParameterAst(AstNulls.At, parameter))];

  public static ParameterAst[] Parameters(this string[] parameters, Func<ParameterAst, ParameterAst> mapping)
    => [.. parameters.Select(parameter => mapping(new ParameterAst(AstNulls.At, parameter)))];

  private static TResult[] WithExcludes<TInput, TResult>(this TInput[] inputs, Func<TInput, TResult> mapping)
    where TResult : AstDomainItem
  {
    var exclude = true;

    return [.. inputs.Select(i => mapping(i) with { Excludes = exclude = !exclude })];
  }

  public static DomainTrueFalseAst[] DomainTrueFalses(this bool[] members)
    => [.. members.WithExcludes(r => new DomainTrueFalseAst(AstNulls.At, false, r))];

  public static DomainMemberAst[] DomainMembers(this string[] members)
    => [.. members.WithExcludes(r => new DomainMemberAst(AstNulls.At, false, r))];

  public static DomainRangeAst[] DomainRanges(this DomainRangeInput[] ranges)
    => [.. ranges.WithExcludes(r => new DomainRangeAst(AstNulls.At, false, r.Lower, r.Upper))];

  public static DomainRegexAst[] DomainRegexes(this string[] regexes)
    => [.. regexes.WithExcludes(r => new DomainRegexAst(AstNulls.At, false, r))];

  public static TypeParameterAst[] TypeParameters(this string[] parameters)
    => [.. parameters.Select(parameter => new TypeParameterAst(AstNulls.At, parameter))];
}
