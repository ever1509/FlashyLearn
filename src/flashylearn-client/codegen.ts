
import type { CodegenConfig } from '@graphql-codegen/cli';

const config: CodegenConfig = {
  overwrite: true,
  schema: "https://localhost:7096/graphql/",
  documents: "**/*.{gql,graphql}",
  generates: {
    "src/graphql/generated/schema.ts": {
      plugins: ['typescript', 'typescript-operations', 'typescript-react-apollo']
    }
  }
};

export default config;
