using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus;

public static class OperationTestHelpers
{
  public static IGqlpDirective[] Directives(this string[] directives)
    => [.. directives.Select(d => new DirectiveAst(AstNulls.At, d))];

  public static IGqlpSelection[] Fields(this string[] fields)
    => [.. fields.Select(f => new FieldAst(AstNulls.At, f))];

  public static IGqlpArg[] Args(this string[] values)
    => [.. values.Select(l => new ArgAst(l.FieldKey()))];

  public static IGqlpArg[] ArgList(this string value)
    => [new ArgAst(AstNulls.At, value), new ArgAst(value.FieldKey())];

  public static IGqlpFields<IGqlpArg> ArgObject(this string value, string key)
  {
    IGqlpFieldKey keyAst = key.FieldKey();
    IGqlpFieldKey valueAst = value.FieldKey();

    return key == value
      ? new AstFields<IGqlpArg>() { [keyAst] = new ArgAst(AstNulls.At, value) }
      : new AstFields<IGqlpArg>() { [keyAst] = new ArgAst(AstNulls.At, value), [valueAst] = new ArgAst(keyAst) };
  }
}
