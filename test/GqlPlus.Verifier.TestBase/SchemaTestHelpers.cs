using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

public static class SchemaTestHelpers
{
  public static AlternateAst<T>[] Alternates<T>(this string argument, Func<string, T> factory)
    where T : AstReference<T>
    => new[] { new AlternateAst<T>(factory(argument)) { Modifiers = TestMods() } };

  public static EnumValueAst[] EnumValues(this string[] enumValues)
    => [.. enumValues.Select(l => new EnumValueAst(AstNulls.At, l))];

  public static InputFieldAst[] InputFields(this string fieldName, string fieldType)
    => new InputFieldAst[] { new(AstNulls.At, fieldName, new(AstNulls.At, fieldType)) };

  public static InputReferenceAst[] InputReferences(this string argument)
    => new InputReferenceAst[] { new(AstNulls.At, argument) };

  public static OutputFieldAst[] OutputFields(this string fieldName, string fieldType)
    => new OutputFieldAst[] { new(AstNulls.At, fieldName, new(AstNulls.At, fieldType)) };

  public static OutputReferenceAst[] OutputReferences(this string argument)
    => new OutputReferenceAst[] { new(AstNulls.At, argument) };

  public static ParameterAst[] Parameters(this string[] parameters)
    => [.. parameters.Select(parameter => new ParameterAst(AstNulls.At, parameter))];

  public static ParameterAst[] Parameters(this string[] parameters, Func<ParameterAst, ParameterAst> mapping)
    => [.. parameters.Select(parameter => mapping(new ParameterAst(AstNulls.At, parameter)))];

  public static ScalarRegexAst[] ScalarRegexes(this string regex, params string[] regexes)
    => [.. regexes.Select(r => new ScalarRegexAst(AstNulls.At, r, false)).Prepend(new(AstNulls.At, regex, true))];

  public static TypeParameterAst[] TypeParameters(this string[] parameters)
    => [.. parameters.Select(parameter => new TypeParameterAst(AstNulls.At, parameter))];
}
