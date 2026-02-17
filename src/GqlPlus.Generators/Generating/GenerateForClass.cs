namespace GqlPlus.Generating;

internal abstract class GenerateForClass<TClass, TMember>
  : GenerateForType<TClass>
  where TClass : IGqlpType
{
  protected GenerateForClass()
  {
    _generators[GqlpGeneratorType.Interface] = GenerateBlock(InterfaceHeader, TypeMembers, InterfaceMember);
    _generators[GqlpGeneratorType.Implementation] = GenerateBlock(ClassHeader, TypeMembers, ClassMember);
  }

  protected virtual void ClassHeader(TClass ast, GqlpGeneratorContext context)
  {
    context.Write("public class " + context.TypeName(ast, ""));
    if (context.GeneratorOptions.BaseType == GqlpBaseType.Class) {
      context.Write("  : " + context.GeneratorOptions.BaseName);
    } else {
      context.Write($"  // No Base because it's {context.GeneratorOptions.BaseType}");
    }
  }

  protected abstract void ClassMember(TMember item, GqlpGeneratorContext context);

  protected virtual void InterfaceHeader(TClass ast, GqlpGeneratorContext context)
  {
    context.Write("public interface " + context.TypeName(ast, "I"));
    if (context.GeneratorOptions.BaseType == GqlpBaseType.Interface) {
      context.Write("  : " + context.GeneratorOptions.BaseName);
    } else {
      context.Write($"  // No Base because it's {context.GeneratorOptions.BaseType}");
    }
  }

  protected abstract void InterfaceMember(TMember item, GqlpGeneratorContext context);

  internal abstract IEnumerable<TMember> TypeMembers(TClass ast, GqlpGeneratorContext context);
}
