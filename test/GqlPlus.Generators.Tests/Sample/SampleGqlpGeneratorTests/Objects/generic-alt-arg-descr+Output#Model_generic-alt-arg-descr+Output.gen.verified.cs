//HintName: Model_generic-alt-arg-descr+Output.gen.cs
// Generated from generic-alt-arg-descr+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_alt_arg_descr_Output;

public interface IGnrcAltArgDescrOutp<Ttype>
{
  RefGnrcAltArgDescrOutp<Ttype> AsRefGnrcAltArgDescrOutp { get; }
}
public class OutputGnrcAltArgDescrOutp<Ttype>
  : IGnrcAltArgDescrOutp<Ttype>
{
  public RefGnrcAltArgDescrOutp<Ttype> AsRefGnrcAltArgDescrOutp { get; set; }
}

public interface IRefGnrcAltArgDescrOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcAltArgDescrOutp<Tref>
  : IRefGnrcAltArgDescrOutp<Tref>
{
  public Tref Asref { get; set; }
}
