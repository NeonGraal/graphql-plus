namespace GqlPlus.Generating;

internal abstract class GenerateForClass<TClass, TMember>
  : GenerateForType<TClass>
  where TClass : IGqlpType
{
  protected GenerateForClass()
  {
    AddGenerator(GqlpGeneratorType.Interface, InterfaceHeader, TypeMembers, InterfaceMember);
    AddGenerator(GqlpGeneratorType.Implementation, ClassHeader, TypeMembers, ClassMember, ClassTail);
  }

  protected virtual void ClassHeader(TClass ast, GqlpGeneratorContext context)
  {
    string interfaceSep = TypeHeader(ast, context, "class", "", GqlpBaseType.Class);
    TypeInterface(ast, context, interfaceSep);
  }

  protected abstract void ClassMember(TMember item, GqlpGeneratorContext context);

  protected virtual void ClassTail(TClass ast, GqlpGeneratorContext context)
  { }

  protected virtual void InterfaceHeader(TClass ast, GqlpGeneratorContext context)
    => TypeHeader(ast, context, "interface", "I", GqlpBaseType.Interface);

  protected abstract void InterfaceMember(TMember item, GqlpGeneratorContext context);

  protected abstract string TypeHeader(TClass ast, GqlpGeneratorContext context, string type, string prefix, GqlpBaseType baseType);

  protected virtual void TypeInterface(TClass ast, GqlpGeneratorContext context, string interfaceSep)
    => context.Write("  " + interfaceSep + " " + context.TypeName(ast, "I"));

  internal abstract IEnumerable<TMember> TypeMembers(TClass ast, GqlpGeneratorTypes types);
}
