using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating;

internal interface ITypeGenerator
{
  bool ForType(IAstType ast);
  void GenerateType(IAstType ast, GqlpGeneratorContext context);
}
