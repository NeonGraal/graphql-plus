using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

internal static class SchemaTestHelpers
{
  public static DualFieldAst[] DualFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new DualFieldAst(AstNulls.At, f.Name, ObjBase(f.Type, f.TypeParam)))];

  public static InputFieldAst[] InputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new InputFieldAst(AstNulls.At, f.Name, ObjBase(f.Type, f.TypeParam)))];

  public static OutputFieldAst[] OutputFields(this IEnumerable<FieldInput> fields)
    => [.. fields.Select(f => new OutputFieldAst(AstNulls.At, f.Name, ObjBase(f.Type, f.TypeParam)))];

  public static AlternateAst[] Alternates(this IEnumerable<TypeInput> alternates)
    => [.. alternates.Select(a => new AlternateAst(AstNulls.At, a.Type, "") { Modifiers = TestMods(), IsTypeParam = a.TypeParam })];

  private static ObjBaseAst ObjBase(string type, bool isTypeParam)
    => new(AstNulls.At, type, "") { IsTypeParam = isTypeParam };

  public static TypeArgAst[] TypeArgs(this string[] arguments)
    => [.. arguments.Select(a => new TypeArgAst(AstNulls.At, a, ""))];

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

  public static DomainRegexAst[] DomainRegexes(this string[] regexes)
    => [.. regexes.WithExcludes(r => new DomainRegexAst(AstNulls.At, "", false, r))];

  public static TypeParamAst[] TypeParams(this string[] parameters)
    => [.. parameters.Select(parameter => new TypeParamAst(AstNulls.At, parameter, "_Any"))];
}
