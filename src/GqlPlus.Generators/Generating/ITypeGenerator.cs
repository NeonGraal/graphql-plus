namespace GqlPlus.Generating;

public interface ITypeGenerator
{
  bool ForType(IAstType ast);
  void GenerateType(IAstType ast, GqlpGeneratorContext context);
}
