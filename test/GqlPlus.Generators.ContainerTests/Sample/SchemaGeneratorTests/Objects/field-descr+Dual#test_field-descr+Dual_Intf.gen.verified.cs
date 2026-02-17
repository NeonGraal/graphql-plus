//HintName: test_field-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Dual;

public interface ItestFieldDescrDual
  : IGqlpModelImplementationBase
{
  ItestFieldDescrDualObject? As_FieldDescrDual { get; }
}

public interface ItestFieldDescrDualObject
  : IGqlpModelImplementationBase
{
  string Field { get; }
}
