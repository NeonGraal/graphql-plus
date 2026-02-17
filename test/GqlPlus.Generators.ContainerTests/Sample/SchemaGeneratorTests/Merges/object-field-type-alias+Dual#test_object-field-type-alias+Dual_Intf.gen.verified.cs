//HintName: test_object-field-type-alias+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Dual;

public interface ItestObjFieldTypeAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasDualObject AsObjFieldTypeAliasDual { get; }
}

public interface ItestObjFieldTypeAliasDualObject
{
  string Field { get; }
}
