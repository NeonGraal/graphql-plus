﻿//HintName: test_field-object+Dual_Impl.gen.cs
// Generated from field-object+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public class testFieldObjDual
  : ItestFieldObjDual
{
  public FldFieldObjDual field { get; set; }
}

public class testFldFieldObjDual
  : ItestFldFieldObjDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
