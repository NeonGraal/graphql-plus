//HintName: test_object-field-alias+Dual_Impl.gen.cs
// Generated from object-field-alias+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

public class testObjFieldAliasDual
  : ItestObjFieldAliasDual
{
  public ItestFldObjFieldAliasDual Field { get; set; }
  public ItestObjFieldAliasDualObject AsObjFieldAliasDual { get; set; }
}

public class testFldObjFieldAliasDual
  : ItestFldObjFieldAliasDual
{
  public ItestFldObjFieldAliasDualObject AsFldObjFieldAliasDual { get; set; }
}
