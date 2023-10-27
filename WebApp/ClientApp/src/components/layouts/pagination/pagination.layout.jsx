import { Box, Pagination } from "@mui/material";

export default function PaginationLayout(){
  return (
    <Box>
      <Pagination count={10} size="small" shape="rounded" />
    </Box>
  );
}