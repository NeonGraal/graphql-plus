//HintName: test_constraint-alt-obj+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public interface ItestCnstAltObjOutp
  // No Base because it's Class
{
  ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp>? AsRefCnstAltObjOutp { get; }
  ItestCnstAltObjOutpObject? As_CnstAltObjOutp { get; }
}

public interface ItestCnstAltObjOutpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltObjOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltObjOutpObject<TRef>? As_RefCnstAltObjOutp { get; }
}

public interface ItestRefCnstAltObjOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstAltObjOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstAltObjOutpObject? As_PrntCnstAltObjOutp { get; }
}

public interface ItestPrntCnstAltObjOutpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  ItestAltCnstAltObjOutpObject? As_AltCnstAltObjOutp { get; }
}

public interface ItestAltCnstAltObjOutpObject
  : ItestPrntCnstAltObjOutpObject
{
  decimal Alt { get; }
}
