//HintName: Model_all.gen.cs
// Generated from all.graphql+
/*
category { All }
directive @all { All }
enum One { Two Three }
input Param { afterId: Guid? beforeId: Guid | String }
output All { items(Param?): String[] | String }
domain Guid { String /[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}/ }
*/
namespace GqlPlus;
public class Model_all {}