//HintName: test_object-field+Dual_Impl.gen.cs
// Generated from object-field+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

public class testObjFieldDual
  : ItestObjFieldDual
{
  public ItestFldObjFieldDual Field { get; set; }
  public ItestObjFieldDualObject AsObjFieldDual { get; set; }
}

public class testFldObjFieldDual
  : ItestFldObjFieldDual
{
  public ItestFldObjFieldDualObject AsFldObjFieldDual { get; set; }
}
