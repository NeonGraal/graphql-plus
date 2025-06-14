using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

internal static class SchemaTestHelpers
{
  public static DualFieldAst[] DualFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new DualFieldAst(AstNulls.At, f.Name, DualBase(f.Type, f.TypeParam)))];

  public static DualAlternateAst[] DualAlternates(this IEnumerable<AlternateInput> alternates)
    => [.. alternates.Select(a => new DualAlternateAst(AstNulls.At, a.Type, "") { Modifiers = TestMods(), IsTypeParam = a.TypeParam })];

  private static DualBaseAst DualBase(string type, bool isTypeParam)
    => new(AstNulls.At, type) { IsTypeParam = isTypeParam };

  public static DualBaseAst[] DualBases(this string[] bases)
    => [.. bases.Select(b => new DualBaseAst(AstNulls.At, b))];

  public static DualArgAst[] DualArgs(this string[] arguments)
    => [.. arguments.Select(b => new DualArgAst(AstNulls.At, b))];

  public static InputFieldAst[] InputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new InputFieldAst(AstNulls.At, f.Name, InputBase(f.Type, f.TypeParam)))];
  public static InputAlternateAst[] InputAlternates(this IEnumerable<AlternateInput> alternates)
    => [.. alternates.Select(a => new InputAlternateAst(AstNulls.At, a.Type, "") { Modifiers = TestMods(), IsTypeParam = a.TypeParam })];

  private static InputBaseAst InputBase(string type, bool isTypeParam)
    => new(AstNulls.At, type) { IsTypeParam = isTypeParam };

  public static InputBaseAst[] InputBases(this string[] bases)
    => [.. bases.Select(a => new InputBaseAst(AstNulls.At, a))];

  public static InputArgAst[] InputArgs(this string[] arguments)
    => [.. arguments.Select(a => new InputArgAst(AstNulls.At, a))];

  public static OutputFieldAst[] OutputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new OutputFieldAst(AstNulls.At, f.Name, OutputBase(f.Type, f.TypeParam)))];

  public static OutputAlternateAst[] OutputAlternates(this IEnumerable<AlternateInput> alternates)
    => [.. alternates.Select(a => new OutputAlternateAst(AstNulls.At, a.Type, "") { Modifiers = TestMods(), IsTypeParam = a.TypeParam })];

  private static OutputBaseAst OutputBase(string type, bool isTypeParam)
    => new(AstNulls.At, type) { IsTypeParam = isTypeParam };

  public static OutputBaseAst[] OutputBases(this string[] arguments)
    => [.. arguments.Select(a => new OutputBaseAst(AstNulls.At, a))];

  public static OutputArgAst[] OutputArgs(this string[] arguments)
    => [.. arguments.Select(a => new OutputArgAst(AstNulls.At, a))];

  public static InputParamAst[] Params(this IEnumerable<string> parameters)
    => [.. parameters.Select(parameter => new InputParamAst(AstNulls.At, parameter))];

  public static InputParamAst[] Params(this string[] parameters, Func<InputParamAst, InputParamAst> mapping)
    => [.. parameters.Select(parameter => mapping(new InputParamAst(AstNulls.At, parameter)))];

  private static TResult[] WithExcludes<TInput, TResult>(this TInput[] inputs, Func<TInput, TResult> mapping)
    where TResult : AstDomainItem
  {
    bool exclude = true;

    return [.. inputs.Select(i => mapping(i) with { Excludes = exclude = !exclude })];
  }

  public static DomainTrueFalseAst[] DomainTrueFalses(this bool[] bools)
    => [.. bools.WithExcludes(r => new DomainTrueFalseAst(AstNulls.At, "", false, r))];

  public static DomainLabelAst[] DomainLabels(this string[] labels)
    => [.. labels.WithExcludes(r => new DomainLabelAst(AstNulls.At, "", false, r))];

  public static DomainRangeAst[] DomainRanges(this DomainRangeInput[] ranges)
    => [.. ranges.WithExcludes(r => new DomainRangeAst(AstNulls.At, "", false, r.Lower, r.Upper))];

  public static DomainRegexAst[] DomainRegexes(this string[] regexes)
    => [.. regexes.WithExcludes(r => new DomainRegexAst(AstNulls.At, "", false, r))];

  public static TypeParamAst[] TypeParams(this string[] parameters)
    => [.. parameters.Select(parameter => new TypeParamAst(AstNulls.At, parameter) { Constraint = "_Any" })];
}
