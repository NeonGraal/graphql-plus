using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

internal static class SchemaTestHelpers
{
  public static EnumMemberAst[] EnumMembers(this IEnumerable<string> enumMembers)
    => [.. enumMembers.Select(l => new EnumMemberAst(AstNulls.At, l))];

  public static DualFieldAst[] DualFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new DualFieldAst(AstNulls.At, f.Name, DualBase(f.Type, f.TypeParameter)))];

  public static DualAlternateAst[] DualAlternates(this IEnumerable<AlternateInput> alternates)
    => [.. alternates.Select(a => new DualAlternateAst(AstNulls.At, DualBase(a.Type, a.TypeParameter)) { Modifiers = TestMods() })];

  private static DualBaseAst DualBase(string type, bool isTypeParameter)
    => new(AstNulls.At, type) { IsTypeParameter = isTypeParameter };

  public static DualBaseAst[] DualBases(this string[] bases)
    => [.. bases.Select(b => new DualBaseAst(AstNulls.At, b))];

  public static DualArgumentAst[] DualArguments(this string[] arguments)
    => [.. arguments.Select(b => new DualArgumentAst(AstNulls.At, b))];

  public static InputFieldAst[] InputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new InputFieldAst(AstNulls.At, f.Name, InputBase(f.Type, f.TypeParameter)))];
  public static InputAlternateAst[] InputAlternates(this IEnumerable<AlternateInput> alternates)
    => [.. alternates.Select(a => new InputAlternateAst(AstNulls.At, InputBase(a.Type, a.TypeParameter)) { Modifiers = TestMods() })];

  private static InputBaseAst InputBase(string type, bool isTypeParameter)
    => new(AstNulls.At, type) { IsTypeParameter = isTypeParameter };

  public static InputBaseAst[] InputBases(this string[] bases)
    => [.. bases.Select(a => new InputBaseAst(AstNulls.At, a))];

  public static InputArgumentAst[] InputArguments(this string[] arguments)
    => [.. arguments.Select(a => new InputArgumentAst(AstNulls.At, a))];

  public static OutputFieldAst[] OutputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new OutputFieldAst(AstNulls.At, f.Name, OutputBase(f.Type, f.TypeParameter)))];

  public static OutputAlternateAst[] OutputAlternates(this IEnumerable<AlternateInput> alternates)
    => [.. alternates.Select(a => new OutputAlternateAst(AstNulls.At, OutputBase(a.Type, a.TypeParameter)) { Modifiers = TestMods() })];

  private static OutputBaseAst OutputBase(string type, bool isTypeParameter)
    => new(AstNulls.At, type) { IsTypeParameter = isTypeParameter };

  public static OutputBaseAst[] OutputBases(this string[] arguments)
    => [.. arguments.Select(a => new OutputBaseAst(AstNulls.At, a))];

  public static OutputArgumentAst[] OutputArguments(this string[] arguments)
    => [.. arguments.Select(a => new OutputArgumentAst(AstNulls.At, a))];

  public static InputParameterAst[] Parameters(this IEnumerable<string> parameters)
    => [.. parameters.Select(parameter => new InputParameterAst(AstNulls.At, parameter))];

  public static InputParameterAst[] Parameters(this string[] parameters, Func<InputParameterAst, InputParameterAst> mapping)
    => [.. parameters.Select(parameter => mapping(new InputParameterAst(AstNulls.At, parameter)))];

  private static TResult[] WithExcludes<TInput, TResult>(this TInput[] inputs, Func<TInput, TResult> mapping)
    where TResult : AstDomainItem
  {
    bool exclude = true;

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
